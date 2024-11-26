import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class StatusRepository {
  private endPoint = 'https://localhost:44344/api/LotoFacilStatus/';

  constructor(private http: HttpClient) {}

  getLast(): Observable<any> {
    return this.http.get<any>(`https://localhost:44344/api/LotoFacilStatus/last`);
  }

  getById(id: number): Observable<any> {
    return this.http.get<any>(`${this.endPoint}${id}`);
  }
}
