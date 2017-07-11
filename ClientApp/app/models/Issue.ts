import { Book } from "./Book";
import { Title } from "./Title";
import { Tag, IssueTag } from "./Tag";

export class Issue {
    IssueId: number;
    IssueNumber: number;
    IssueReleaseDate?: Date;
    IssuePrice?: number;
    GcdIssueId: number;
    Title: Title;
    Books: Array<Book>;
    Tags: Array<IssueTag>;
}
