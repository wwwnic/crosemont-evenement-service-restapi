import { Component, OnInit } from '@angular/core';

import { Evenement } from 'src/app/Evenement';
import { EvenementService } from 'src/app/services/evenement.service';
import { DeleteKey } from 'src/app/deleteKey';

@Component({
  selector: 'app-evenement',
  templateUrl: './evenement.component.html',
  styleUrls: ['./evenement.component.css']
})
export class EvenementComponent implements OnInit {

  evenements!: Evenement[];
  constructor(private evenementService: EvenementService) {
    this.evenementService.getAll().subscribe((evenements) => (this.evenements = evenements));
  }

  consulterEvenement(evenement: Evenement) {
    console.log(evenement);
  }

  updateEvenement(evenement: Evenement) {
    this.evenementService.updateEvenement(evenement).subscribe();
  }

  deleteEvenement(deleteKey: DeleteKey) {
    this.evenementService.deleteEvenement(deleteKey).subscribe(() => this.evenements.filter(e => e.idEvenement !== deleteKey.id));
  }

  ngOnInit(): void {
  }

}
