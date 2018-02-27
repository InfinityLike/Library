import { GetPublisherViewItem } from '../publisher/getPublisherViewItem';
import { GetAuthorViewItem } from '../author/getAuthorViewItem';

export class GetBookViewItem {
    id: number
    name: string
    authors: Array<GetAuthorViewItem>
    dateOfPublishing: Date
    type: string
    publishers: Array<GetPublisherViewItem>
}
