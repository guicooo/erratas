import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarItensComponent } from './adicionar-itens.component';

describe('AdicionarItensComponent', () => {
  let component: AdicionarItensComponent;
  let fixture: ComponentFixture<AdicionarItensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarItensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarItensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
