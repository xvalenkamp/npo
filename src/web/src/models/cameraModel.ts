export interface ICameraReponse {
  id?: number;
  camera?: string;
  latitude?: string;
  longitude?: string;
}

export interface ICameraRequest {
  streetName?: string;
  cameraId?: number;
}
