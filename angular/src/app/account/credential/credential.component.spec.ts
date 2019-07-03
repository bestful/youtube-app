import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CredentionalComponent } from './credential.component';

describe('CredentionalComponent', () => {
  let component: CredentionalComponent;
  let fixture: ComponentFixture<CredentionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CredentionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CredentionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
