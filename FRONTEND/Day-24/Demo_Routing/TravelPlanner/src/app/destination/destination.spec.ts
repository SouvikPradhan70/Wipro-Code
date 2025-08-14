import { ComponentFixture, TestBed } from '@angular/core/testing';

// import { Destination } from './destination';
// import { Destination } from './destination'; // ❌ This does not exist
import { DestinationComponent } from './destination';


describe('Destination', () => {
  let component: DestinationComponent;
  let fixture: ComponentFixture<DestinationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DestinationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
