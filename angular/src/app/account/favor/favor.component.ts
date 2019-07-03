import { Component, OnInit } from '@angular/core';
import { ApiService } from "../../service"
import { Video } from 'src/app/model';
import { forEach } from '@angular/router/src/utils/collection';
import { Url } from 'url';
import { DomSanitizer } from '@angular/platform-browser';
import { THROW_IF_NOT_FOUND } from '@angular/core/src/di/injector';


@Component({
  selector: 'app-favor',
  templateUrl: './favor.component.html',
  styleUrls: ['./favor.component.scss']
})
export class FavorComponent implements OnInit {

  constructor(private api: ApiService, public domSanitizer: DomSanitizer) {
    this.items;
  }

  items: Array<Video> = new Array<Video>();


  repairLink(link) {
    return link.replace(/\/watch\?v=(.{11})/, '/embed/$1');
  }


  getFavors() {
    let uid = 1;
    // Select list of videos ids
    // this.api.get('item', 1).toPromise().then(res_ => {
    //   let res = res_ as any;
    //   for(let item of res){
    //   this.api.get('video', item.video_id).toPromise().then(
    //     videos => {  
    //       for (x in videos){
            
    //       }
    //     });
    //   }
    // }
    // );
    // this.api.get('item', uid, {}).subscribe(() => console.log(), () => console.log(),() => console.log(2112));

    this.api.get('item').subscribe(
      data => {
        console.log(data);
// tslint:disable-next-line: forin
        for (const id in data){
          const videoId = data[id].videoId;
          this.api.get('video', videoId).subscribe(
            data => {
              let video = data as any as Video;
              // video.link = this.repairLink(video.link);
              video.link = this.domSanitizer.bypassSecurityTrustResourceUrl(this.repairLink(video.link));
              
              this.items.push(video);
            }
          );

        }
      },
      error => {

      }
    );
}

ngOnInit() {
  this.getFavors();
}

}
