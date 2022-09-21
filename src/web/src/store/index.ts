import { ICameraReponse, ICameraRequest } from "@/models/cameraModel";
import { createStore } from "vuex";
import axios from "axios";

export default createStore({
  state: {
    cameras: null,
  },
  getters: {},
  mutations: {
    setCameras(state: any, cameras: ICameraReponse[]) {
      state.cameras = cameras.filter(
        (camera: ICameraReponse) => !camera.camera?.includes("ERROR")
      );
    },
  },
  actions: {
    getCameras({ commit }: { commit: Function }, request: ICameraRequest) {
      const url =
        process.env.VUE_APP_BACKENDURL +
        `/api/v1/Cameras?streetName=${request.streetName}`;
      const config = {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*",
        },
      };

      return axios.get<ICameraReponse[]>(url, config).then((result) => {
        commit("setCameras", result.data);
      });
    },
  },
  modules: {},
});
