import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetrospectiveTemplateComponent } from './retrospective-template.component';

describe('RetrospectiveTemplateComponent', () => {
  let component: RetrospectiveTemplateComponent;
  let fixture: ComponentFixture<RetrospectiveTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RetrospectiveTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RetrospectiveTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
