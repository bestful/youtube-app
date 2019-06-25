import { Component, OnInit } from '@angular/core';
import { ApiService } from "../../service"
import { Video } from 'src/app/model';
import { forEach } from '@angular/router/src/utils/collection';
import { Url } from 'url';
import { DomSanitizer } from '@angular/platform-browser';


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
    // this.api.get('items', uid, {}).then(res_ => {
    //   let res = res_ as any;
    //   for(let item of res){
    //   this.api.get('videos', item.video_id).then(
    //     video_ => {  
    //       let video = video_ as any as Video; 
    //       // Update items
    //       video.link = this.repairLink(video.link);
    //       video.link = this.domSanitizer.bypassSecurityTrustResourceUrl(video.link as string);
    //       this.items.push(video);
    //     });
    //   }
    // }
    // );
    this.api.get('IteminVideosforUser', uid, {}).subscribe(() => console.log(), () => console.log(),() => console.log(2112));
}

ngOnInit() {
  this.getFavors();
}

}
