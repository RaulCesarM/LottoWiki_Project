import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class OverdueRepository {

  constructor(private http: HttpClient) {}

  private endPoint = 'https://localhost:44344/api/LotoFacilOverDue/last/'; 

  getData(): Observable<any> {    
    return this.http.get<any>(this.endPoint);
  } 

}