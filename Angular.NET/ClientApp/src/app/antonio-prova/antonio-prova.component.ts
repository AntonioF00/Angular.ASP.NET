import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector:    'antonio-prova',
  templateUrl: './antonio-prova.component.html',
  styleUrls: ['./antonio-prova.component.css'],
})
export class AntonioProvaComponent {

  public users: Array<User> = [];

  constructor(http: HttpClient,
              @Inject('BASE_URL') baseUrl: string) {

    http.get<Array<User>>(baseUrl + 'usercontroller').subscribe(result => {
      this.users = result;
    }, error => console.error(error));

  }
}
 interface User {
  name:         string;
  surname:      string;
  description:  string;
  email:        string;
  phone_number: string;
}
