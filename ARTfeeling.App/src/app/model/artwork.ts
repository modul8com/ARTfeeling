import { ArtType } from "./art-type.enum";
import { ExpositionRoom } from "./exposition-room";

export class Artwork {
    id: number;
    title: string;
    remarks: string;
    height: number;
    width: number;
    depth: number;
    typeOfArtWork: ArtType;

    pictures: string;
    exposedAt: ExpositionRoom;
}
