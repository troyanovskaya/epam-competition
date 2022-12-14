import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpRequestService } from 'src/app/services/http-request.service';

@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.css']
})
export class EmailConfirmationComponent implements OnInit {
  email: string | null = "";
  token: string | null = "";

  constructor(private httpRequestService: HttpRequestService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getRouteParams();
  }

  getRouteParams(){
    this.route.queryParams.subscribe(params => {
      this.email = params['email']
      this.token = params['token']

      this.confirmEmail(this.email, this.token);
    })
  }

  confirmEmail(email: any, token: any){
    this.httpRequestService.confirmEmail(email, token).subscribe(e => {
      this.router.navigateByUrl('/');
    }, err => console.log(err));
  }
}
