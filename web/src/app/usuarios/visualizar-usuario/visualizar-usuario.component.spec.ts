import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarUsuarioComponent } from './visualizar-usuario.component';

describe('VisualizarUsuarioComponent', () => {
  let component: VisualizarUsuarioComponent;
  let fixture: ComponentFixture<VisualizarUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisualizarUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
