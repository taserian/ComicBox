import { Issue } from "./Issue";
import { Tag } from "./Tag";

export class Title {
    titleId: number;
    publisher?: string;
    seriesTitle: string;
    gcdSeriesId?: number;
    issues?: Array<Issue>;
    tags?: Array<Tag>;
}
