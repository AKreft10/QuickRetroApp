import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetrospectiveBoardComponent } from './retrospective-board.component';

describe('RetrospectiveBoardComponent', () => {
  let component: RetrospectiveBoardComponent;
  let fixture: ComponentFixture<RetrospectiveBoardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RetrospectiveBoardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RetrospectiveBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
