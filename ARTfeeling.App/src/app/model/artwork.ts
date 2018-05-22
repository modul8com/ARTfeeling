import { ArtType } from "./art-type.enum";
import { ExpositionRoom } from "./exposition-room";

export class Artwork {
    Id: number;
    Title: string;
    Remarks: string;
    Height: number;
    Width: number;
    Depth: number;
    TypeOfArtWork: ArtType;

    Pictures: string[];
    ExposedAt: ExpositionRoom;
}
