import { PublisherViewModel } from './publisherViewModel';

export class BookViewModel {
    id: number
    name: string
    author: string
    yearOfPublishing: number
    type: string
    publishers: Array<PublisherViewModel>
}
