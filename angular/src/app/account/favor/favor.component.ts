import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService, OembedService } from "../../service"
import { Video } from 'src/app/model';
import { forEach } from '@angular/router/src/utils/collection';
import { Url } from 'url';
import { DomSanitizer } from '@angular/platform-browser';
import { THROW_IF_NOT_FOUND } from '@angular/core/src/di/injector';
import { ToastrService } from 'ngx-toastr';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AccountService } from '../account.service';


@Component({
  selector: 'app-favor',
  templateUrl: './favor.component.html',
  styleUrls: ['./favor.component.scss']
})
export class FavorComponent implements OnInit {

  constructor(private api: ApiService, public domSanitizer: DomSanitizer, private toastr: ToastrService, public modal: NgxSmartModalService, private account: AccountService) {
 
  }


  items: Array<Video> = new Array<Video>();
  video: Video = new Video();

  selected_mark: string;


  error_lambda: any = error => {
    if (error.status > 0) {
      this.toastr.error(error.error);
    } else {
      this.toastr.error('Connection error!');
    }
  }

  repairLink(link) {
    return link.replace(/\/watch\?v=(.{11})/, '/embed/$1');
  }


  updateFavors() {
    let uid = this.account.id;

    this.api.get('favourite', uid).subscribe(
      data => {
        // tslint:disable-next-line: forin
        for (const id in data){
          const favor = data[id];
          let video: Video = favor;

          // Block of link repairing
          video.link = this.domSanitizer.bypassSecurityTrustResourceUrl(this.repairLink(video.link));

          this.items.push(video);
        }
      },
      this.error_lambda
    );
  }

  createFavor(){
    this.api.post('video', this.video).subscribe(
      next =>  {
        this.modal.getModal('myModal').close();
        this.toastr.success('Video successfully added!');
        this.updateFavors();
      },
      this.error_lambda
    );
  }

  updateVote(id: Number, mark: Number){
    console.log(mark);
    this.api.put('vote', id, {mark: mark});
  }

  deleteFavor(video_id: Number){
    this.api.delete('item', video_id);
  }

ngOnInit() {
  this.updateFavors();
}

}
