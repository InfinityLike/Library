import { PublisherViewModel } from './publisherViewModel';
import { AuthorViewModel } from './authorViewModel';

export class BookViewModel {
    id: number
    name: string
    authors: Array<AuthorViewModel>
    dateOfPublishing: Date
    type: string
    publishers: Array<PublisherViewModel>
}
