import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { People } from '../../models/people';
import { PeopleService } from '../../services/people.service';
import { take } from 'rxjs/operators';
import { PeopleByGender } from '../../models/PeopleByGender';
import * as _ from 'lodash';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html'
})
export class PeopleComponent implements OnInit {
  people: People[] = [];
  peopleByGender: PeopleByGender[] = [];

  constructor(private peopleService: PeopleService) {
  }

  ngOnInit() {
    this.peopleService.getPeople().pipe(take(1)).subscribe((data) => {
      this.people = data;
      this.peopleByGender = _.chain(this.people)
        .groupBy("gender")
        .map((value, key) => {
          const peopleByGender: PeopleByGender = new PeopleByGender();
          peopleByGender.gender = key;
          peopleByGender.people = value;
          return peopleByGender;
        }
        )
        .value();
    });
  }
}
