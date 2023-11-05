import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ItemDetailComponent } from '../item-detail/item-detail.component';
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

  constructor(private readonly queryService: QueryService,
    private readonly modalService: NgbModal) { }

  ngOnInit(): void {
  }

  public async queryData() {
    if (!this.searchText || this.searchText === '') {
      this.resultData = [];
      return;
    }
    this.resultData = await this.queryService.query(this.searchText);
  }

  public openDetails() {
    const modalRef = this.modalService.open(ItemDetailComponent);
  }

}
