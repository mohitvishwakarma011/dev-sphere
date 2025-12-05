import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment.prod";
import { FilterModel } from "src/app/shared/models";


@Injectable()
export class PostService{
    private readonly apiEndPoint = `${environment.apiBaseUrl}/post`;
    constructor(private readonly http:HttpClient){}

    getPosts(filterModel:FilterModel):Observable<any>{
        let queryParams = filterModel.toQueryString();
        return this.http.get(`${this.apiEndPoint}/list?${queryParams}`)
    }
}