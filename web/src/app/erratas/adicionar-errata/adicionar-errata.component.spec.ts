import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarErrataComponent } from './adicionar-errata.component';

describe('AdicionarErrataComponent', () => {
  let component: AdicionarErrataComponent;
  let fixture: ComponentFixture<AdicionarErrataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarErrataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarErrataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
