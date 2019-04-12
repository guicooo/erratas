import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarItensComponent } from './visualizar-itens.component';

describe('VisualizarItensComponent', () => {
  let component: VisualizarItensComponent;
  let fixture: ComponentFixture<VisualizarItensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualizarItensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarItensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
