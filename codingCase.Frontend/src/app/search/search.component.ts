import { Component, OnInit } from '@angular/core';
import { QueryResult } from '../model/queryResult';
import { QueryService } from '../services/query.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public searchText : string | null = null;
  public resultData: QueryResult[] = [];

  constructor(private readonly queryService: QueryService) { }

  ngOnInit(): void {
  }

  public async queryData() {
    if (!this.searchText || this.searchText === '') {
      this.resultData = [];
      return;
    }
    this.resultData = await this.queryService.query(this.searchText);
  }

}
