

export class Tag {
    tagId: number;
    label: string;
}

export class TitleTag {
    titleId: number;
    tagId: number;
}

export class IssueTag {
    issueId: number;
    tagId: number;
}

export class BookTag {
    bookId: number;
    tagId: number;
}

export class BookCondition {
    bookId: number;
    conditionId: number;
}

export class ItemTag extends Tag {
    taggedTitles: Array<TitleTag>;
    taggedIssues: Array<IssueTag>;
    taggedBooks: Array<BookTag>;
}