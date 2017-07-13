import { Issue } from "./Issue";
import { Tag } from "./Tag";

export class Book {
    id: number;
    Location: string;
    BookGrade: Grade;
    CbcsGrade: number;
    CgcGrade: number;
    Issue: Issue;
    BookCondition: Array<Tag>;
    Tags: Array<Tag>;
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