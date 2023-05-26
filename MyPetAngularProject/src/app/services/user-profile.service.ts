import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  baseApiUrl: string = environment.baseApiUrl + "api/" + 'Account';
  token!: string;


  constructor(private http: HttpClient) {
  }

  public loadImage(file: FormData): Observable<any> {
    return this.http.post(this.baseApiUrl + '/load-image', file, {
      reportProgress: true,
      observe: 'events',
    });
  }

  public getProfileImage() : Observable<any>{
    return this.http.get(this.baseApiUrl + 'get-image');
  }
}
