import { Component, Input, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { Title } from '../../models/Title';
import { Tag } from '../../models/Tag';
import { Issue } from '../../models/Issue';
import { TitleService } from '../../services/title.service';

@Component({
    selector: 'title-edit',
    templateUrl: './title-edit.component.html',
    styleUrls: [ './title-edit.component.css' ]
})
export class TitleEditComponent {
    titleForm: FormGroup;
    @Input() title: Title;

    constructor(private fb: FormBuilder, private dbService: TitleService) {
        this.createForm();
    }

    createForm() {
        this.titleForm = this.fb.group({
            seriesTitle: ['', Validators.required],
            publisher: '',
            gcdSeriesId: '',
            titleTags: this.fb.array([]),
            issueNumbers: this.fb.array([])
        })
    }

    ngOnChanges() {
        this.titleForm.reset({
            seriesTitle: this.title.seriesTitle,
            publisher: this.title.publisher || "",
            gcdSeriesId: this.title.gcdSeriesId
        });
        this.setTags(this.title.tags);
        this.setIssues(this.title.issues === null ? [] : this.title.issues);
    }

    // #region Tags
    get tagsArray(): FormArray {
        return this.titleForm.get("titleTags") as FormArray;
    }

    setTags(tags: Tag[]) {
        const tagFGs = tags.map(tag1 => this.fb.group(tag1));
        const tagFormArray = this.fb.array(tagFGs);
        this.titleForm.setControl('titleTags', tagFormArray);
    }

    addTag() {
        this.tagsArray.push(this.fb.group(new Tag()));
    }
    // #endregion

    // #region Issues
    get issuesArray(): FormArray {
        return this.titleForm.get("issueNumbers") as FormArray;
    }

    setIssues(issues: Issue[]) {
        const issuesFGs = issues.map(issue1 => this.fb.group(issue1));
        const tagFormArray = this.fb.array(issuesFGs);
        this.titleForm.setControl('issueNumbers', tagFormArray);
    }

    addIssue() {
        this.issuesArray.push(this.fb.group(new Issue()));
    }
    // #endregion

    onSubmit() {
        this.title = this.prepareSaveTitle();
        this.dbService.saveTitle(this.title);
        this.ngOnChanges();
    }

    prepareSaveTitle(): Title {
        const formModel = this.titleForm.value;
        const tagsDeepCopy: Tag[] = formModel.titleTags
            .map((tag1: Tag) => Object.assign({}, tag1));
        const issuesDeepCopy: Issue[] = formModel.issueNumbers
            .map((issue1: Issue) => Object.assign({}, issue1));

        const saveTitle: Title = {
            titleId: this.title.titleId,
            seriesTitle: formModel.seriesTitle as string,
            publisher: formModel.publisher as string,
            gcdSeriesId: formModel.gcdSeriesId as number,
            tags: tagsDeepCopy,
            issues: issuesDeepCopy
        }
        return saveTitle;
    }

    revert() { this.ngOnChanges(); }

}
