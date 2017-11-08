import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'stringFilter'
})

export class stringFilter implements PipeTransform {

    // Transform is the new "return function(value, args)" in Angular 1.x
    transform(value: string): string {             // a fx which takes input data as string and return in also string
        return (value.trim().replace(/ /g, '-'));  // replace space with '-' in a string
    } 

}