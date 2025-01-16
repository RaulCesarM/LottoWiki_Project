import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class DoOverRepository {

  constructor(private http: HttpClient) {}

  private endPoint = 'https://localhost:44344/api/LotoFacilDoOver/DoOver'; 

  getData(): Observable<any> {    
    return this.http.get<any>(this.endPoint);
  } 

}