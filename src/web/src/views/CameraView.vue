<template>
  <div class="cameraview">
    <div class="camera-header">
      <span>Search</span>
      <input :value="searchTerm" type="text" @change="onStreetNameChange" />
    </div>
    <div class="leaflet-content">
      <camera-map />
    </div>
    <div class="camera-content">
      <camera-list label="Cameras 3" :data="cameras3" />
      <camera-list label="Cameras 5" :data="cameras5" />
      <camera-list label="Cameras 3 & 5" :data="cameras3_5" />
      <camera-list label="Cameras Overig" :data="camerasother" />
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import CameraList from "@/components/CameraList.vue";
import CameraMap from "@/components/CameraMap.vue";
import { mapActions } from "vuex";
import { ICameraReponse, ICameraRequest } from "@/models/cameraModel";

export default defineComponent({
  name: "HomeView",
  components: {
    CameraList,
    CameraMap,
  },
  data() {
    return {
      searchTerm: "Neude",
      iconmarker: {} as any,
    };
  },
  async created() {
    await this.loadCameras();
  },
  methods: {
    ...mapActions({
      getCamerasData: "getCameras",
    }),
    async loadCameras() {
      const request = {
        streetName: this.searchTerm,
        cameraId: undefined,
      } as ICameraRequest;

      await this.getCamerasData(request);
    },
    onStreetNameChange(event: any) {
      this.searchTerm = event.target.value;
      this.loadCameras();
    },
  },
  computed: {
    cameras3() {
      if (!this.$store.state.cameras) {
        return;
      }

      return this.$store.state.cameras.filter(
        (camera: ICameraReponse) =>
          (camera.id ?? 0) % 3 === 0 && (camera.id ?? 0) % 5 !== 0
      );
    },
    cameras5() {
      if (!this.$store.state.cameras) {
        return;
      }

      return this.$store.state.cameras.filter(
        (camera: ICameraReponse) =>
          (camera.id ?? 0) % 5 === 0 && (camera.id ?? 0) % 3 !== 0
      );
    },
    cameras3_5() {
      if (!this.$store.state.cameras) {
        return;
      }

      return this.$store.state.cameras.filter(
        (camera: ICameraReponse) =>
          (camera.id ?? 0) % 3 === 0 && (camera.id ?? 0) % 5 === 0
      );
    },
    camerasother() {
      if (!this.$store.state.cameras) {
        return;
      }

      return this.$store.state.cameras.filter(
        (camera: ICameraReponse) =>
          (camera.id ?? 0) % 3 !== 0 && (camera.id ?? 0) % 5 !== 0
      );
    },
  },
});
</script>

<style lang="scss" scoped>
.cameraview {
  display: flex;
  flex-direction: column;
  padding: 20px;
  height: calc(100% - 40px);
  width: calc(100% - 40px);

  .camera-header {
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
    align-items: center;
    align-content: center;
    font-size: 16px;
    gap: 10px;
    height: 50px;

    input {
      height: 30px;
      font-size: 16px;
    }
  }

  .leaflet-content {
    height: 60%;
    width: 100%;
    background: lightgreen;
    overflow: auto;
  }

  .camera-content {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    gap: 10px;
    height: 40%;
    width: 100%;
    overflow: hidden;
  }
}
</style>
