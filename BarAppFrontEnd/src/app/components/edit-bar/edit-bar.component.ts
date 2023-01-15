import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from 'src/app/services/Service/http-provider.service';

@Component({
  selector: 'app-edit-bar',
  templateUrl: './edit-bar.component.html',
  styleUrls: ['./edit-bar.component.css']
})
export class EditBarComponent implements OnInit {
  editBarForm: BarForm = new BarForm();

  @ViewChild("barForm")
  barForm!: NgForm;

  isSubmitted: boolean = false;
  barId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.barId = this.route.snapshot.params['barId'];
    this.getBarDetailById();
  }
  getBarDetailById() {
    this.httpProvider.getBarDetailById(this.barId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.editBarForm.Id = resultData.Id;
          this.editBarForm.Name = resultData.Name;
          this.editBarForm.Address = resultData.Address;
          this.editBarForm.OpeningTime = resultData.OpeningTime;
          this.editBarForm.ClosingTime = resultData.ClosingTime;
        }
      }
    },
      (error: any) => { });
  }

  EditBar(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveBar(this.editBarForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
          if (resultData != null && resultData.isSuccess) {
            if (resultData != null && resultData.isSuccess) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['/Home']);
              }, 500);
            }
          }
        }
      },
        async error => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['/Home']);
          }, 500);
        });
    }
  }
}

export class BarForm {
  Id: string = "";
  Name: string = "";
  Address: string = "";
  OpeningTime: string = "";
  ClosingTime: string = "";
}