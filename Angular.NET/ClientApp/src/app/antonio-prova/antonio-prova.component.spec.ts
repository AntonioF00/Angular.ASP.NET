import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AntonioProvaComponent } from './antonio-prova.component';

describe('AntonioProvaComponent', () => {
  let component: AntonioProvaComponent;
  let fixture: ComponentFixture<AntonioProvaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AntonioProvaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AntonioProvaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
