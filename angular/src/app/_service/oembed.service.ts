import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { stringify } from '@angular/compiler/src/util';

@Injectable({
  providedIn: 'root'
})
export class OembedService {

  constructor(private http: HttpClient) { }

  getYoutubeEmbed(url: string){
    let json: string;

    this.http.get("https://www.youtube.com/oembed", {'url': url} as any).toPromise().then(data => 
    {
      console.log(data);
    });
    return "";
  }
}
