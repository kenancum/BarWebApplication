import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { WebApiService } from "src/app/services/Service/web-api.service";
import { HttpProviderService } from "src/app/services/Service/http-provider.service";

@Component({
  selector: 'app-view-bar',
  templateUrl: './view-bar.component.html',
  styleUrls: ['./view-bar.component.css']
})
export class ViewBarComponent implements OnInit {
  barId: any;
  barDetail : any= [];
   
  constructor(public webApiService: WebApiService, private route: ActivatedRoute, private httpProvider : HttpProviderService) { }
  
  ngOnInit(): void {
    this.barId = this.route.snapshot.params["barId"];      
    this.getBarDetailById();
  }

  getBarDetailById() {       
    this.httpProvider.getBarDetailById(this.barId).subscribe((data : any) => {      
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.barDetail = resultData;
        }
      }
    },
    (error :any)=> { }); 
  }
}
