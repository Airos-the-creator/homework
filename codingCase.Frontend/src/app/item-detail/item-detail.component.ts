import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ItemDetailProperty } from '../model/itemDetailProperty';
import { QueryService } from '../services/query.service';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.scss']
})
export class ItemDetailComponent implements OnInit {

  public itemId!: string;
  public displayProperties : ItemDetailProperty[] = [];
  constructor(public activeModal: NgbActiveModal,
    private readonly queryService: QueryService) { }

  async ngOnInit() {
    this.displayProperties = (await this.queryService.getItemDetails(this.itemId)).properties;
  }

}
