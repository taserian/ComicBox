import { Issue } from "./Issue";
import { Tag, BookTag, BookCondition } from "./Tag";

export class Book {
    id: number;
    Location: string;
    BookGrade: Grade;
    CbcsGrade: number;
    CgcGrade: number;
    Issue: Issue;
    BookCondition: Array<BookCondition>;
    Tags: Array<BookTag>;
}

export enum Grade {
    UNKNOWN,
    Poor,
    Fair,
    Good,
    VeryGood,
    Fine,
    VeryFine,
    NearMint,
    Mint
}

export class Condition extends Tag {
    ConditionBooks: Array<Book>;
}