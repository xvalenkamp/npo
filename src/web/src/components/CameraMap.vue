<template>
  <div id="mapid" class="mapid"></div>
</template>

<script lang="ts">
import "leaflet/dist/leaflet.css";
import { defineComponent } from "vue";
import L from "leaflet";
import { ICameraReponse } from "@/models/cameraModel";

export default defineComponent({
  name: "CameraMap",
  components: {},
  data() {
    return {
      cameramap: {} as any,
      iconmarker: {} as any,
    };
  },
  mounted() {
    this.configureIcon();
    this.configureCameraMap();
  },
  beforeUnmount() {
    this.cameramap.remove();
  },
  watch: {
    cameras: {
      handler(value: any) {
        if (value === null || value === undefined) {
          return;
        }
        if (this.cameramap) {
          this.cameramap.remove();
        }
        this.configureCameraMap();

        value.forEach((camera: ICameraReponse) => {
          const latitude =
            camera?.latitude === null ||
            camera?.latitude === undefined ||
            camera?.latitude === ""
              ? 0
              : parseFloat(camera.latitude);
          const longitude =
            camera?.longitude === null ||
            camera?.longitude === undefined ||
            camera?.latitude === ""
              ? 0
              : parseFloat(camera.longitude);

          if (latitude > 0 && longitude > 0) {
            L.marker([latitude, longitude], {
              icon: this.iconmarker,
            }).addTo(this.cameramap);
          }
        });
      },
    },
  },
  methods: {
    configureCameraMap() {
      this.cameramap = L.map("mapid").setView([52.0914, 5.1115], 11);

      L.tileLayer("http://{s}.tile.osm.org/{z}/{x}/{y}.png", {
        attribution:
          '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      }).addTo(this.cameramap);
    },
    configureIcon() {
      this.iconmarker = L.icon({
        iconUrl: "video-camera-icon.png",
        iconSize: [30, 30],
      });
    },
    onClick() {
      this.cameramap.clearLayers();
    },
  },
  computed: {
    cameras() {
      return this.$store.state.cameras;
    },
  },
});
</script>

<style lang="scss" scoped>
.mapid {
  height: 100%;
  width: 100%;
}
</style>
