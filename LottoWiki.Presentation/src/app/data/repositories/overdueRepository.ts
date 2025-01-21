import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { OverdueSmall } from "src/app/models/overdueSmall";

@Injectable({ providedIn: 'root' })
export class OverdueRepository {

  constructor(private http: HttpClient) {}

  private endPoint = 'https://localhost:44344/api/LotoFacilOverDue/OverDue'; 

  getData(): Observable<OverdueSmall> { 
    var a =  this.http.get<OverdueSmall>(this.endPoint);  
    console.log('a',a)
    return a
  } 

}