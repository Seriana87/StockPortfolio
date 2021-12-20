import { AfterViewInit, OnDestroy, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SearchResponse } from 'src/app/models/search-response.models';
import { SearchService } from 'src/app/services/search.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';

export interface UsersData {
  name: string;
  id: number;
}

@Component({
  selector: 'app-stock-portfolio',
  templateUrl: './stock-portfolio.component.html',
  styleUrls: ['./stock-portfolio.component.css']
})
export class StockPortfolioComponent implements AfterViewInit  {
  response: SearchResponse[];
  constructor(private jobService: SearchService, public dialog: MatDialog) {
  }

  displayedColumns: string[] = ['id', 'symbol', 'name', 'currentPrice', 'quantity', 'buyValue', 'currentValue', 'yield', 'action'];
  dataSource;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }


  ngOnInit() {   
    this.jobService.searchForStockData()
      .subscribe((res: SearchResponse[]) => {
        this.dataSource = new MatTableDataSource<SearchResponse>(res);
      });
  }

}







