import { Component, OnInit, Input } from '@angular/core';
import { WebApiService } from 'src/app/services/web-api.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-show-travels',
  templateUrl: './show-travels.component.html',
  styleUrls: ['./show-travels.component.css']
})
export class ShowTravelsComponent implements OnInit {

  constructor(private webapi: WebApiService, private route: ActivatedRoute, private router: Router) { }
  @Input() id:number;
public name:string;
  ngOnInit() {
    this.webapi.GetNameById(this.id).subscribe(y => {
      this.name=y});
  }
}
