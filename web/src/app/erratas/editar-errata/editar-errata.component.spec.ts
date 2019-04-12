import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarErrataComponent } from './editar-errata.component';

describe('EditarErrataComponent', () => {
  let component: EditarErrataComponent;
  let fixture: ComponentFixture<EditarErrataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarErrataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarErrataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
