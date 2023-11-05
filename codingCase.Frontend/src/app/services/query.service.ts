import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { QueryResult } from '../model/queryResult';
import { environment } from '../../environments/environment';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QueryService {

  private baseUrl = environment.backendUrl;

  constructor(private readonly httpClient: HttpClient) { }

  public query(searchString: string) :Promise<QueryResult[]>{
    return firstValueFrom(this.httpClient.get<QueryResult[]>(`${this.baseUrl}/query/?searchString=${searchString}`));
  }
}
