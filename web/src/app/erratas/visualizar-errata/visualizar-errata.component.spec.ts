import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarErrataComponent } from './visualizar-errata.component';

describe('VisualizarErrataComponent', () => {
  let component: VisualizarErrataComponent;
  let fixture: ComponentFixture<VisualizarErrataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualizarErrataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarErrataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
