export class FilterModel{
    filterKey:string;
    pageSize:number;
    pageIndex:number;
    sort:string;
    order:string;

    constructor(){
        this.order = "asc";
        this.pageIndex = 0;
        this.pageSize = 10;
    }

    toQueryString(): string {
        let queryString = `sort=${this.sort}&order=${this.order}&pageIndex=${this.pageIndex}&pageSize=${this.pageSize}`;

        if (this.filterKey !== '' && this.filterKey !== null && this.filterKey !== undefined) {
            queryString += '&filterKey=' + this.filterKey;
        }
        return queryString;
    }
}