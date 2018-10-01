import { ArtType } from "./art-type.enum";
import { ExpositionRoom } from "./exposition-room";

export class Artwork {
    partitionKey: string;
    rowKey: string;
    title: string;
    remarks: string;
    height: number;
    width: number;
    depth: number;
    typeOfArtWork: ArtType;

    pictures: string[];
    exposedAtpartitionKey: string;
    exposedAtrowKey: string;
}
