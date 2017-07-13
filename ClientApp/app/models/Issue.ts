import { Book } from "./Book";
import { Title } from "./Title";
import { Tag } from "./Tag";

export class Issue {
    issueId: number;
    issueNumber: number;
    issueReleaseDate?: Date;
    issuePrice?: number;
    gcdIssueId?: number;
    title?: Title;
    books: Array<Book>;
    tags: Array<Tag>;
}
