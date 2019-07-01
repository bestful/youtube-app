import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appAutofocus]'
})
export class AutofocusDirective {

  constructor(private el: ElementRef) { }

  ngOnInit(){
    
    setTimeout(() => {

      this.el.nativeElement.focus();

  }, 500);
  }

}
