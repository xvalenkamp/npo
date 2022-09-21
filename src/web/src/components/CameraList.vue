<template>
  <div class="cameralist">
    <div class="cameralist-label">
      <span>{{ label }}</span>
    </div>
    <div class="camera-table">
      <table>
        <thead>
          <tr>
            <th>
              <span>Number</span>
            </th>
            <th>
              <span>Name</span>
            </th>
            <th>
              <span>Latitude</span>
            </th>
            <th>
              <span>Longitude</span>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="row in data" :key="row">
            <td>{{ row.id }}</td>
            <td>{{ row.camera }}</td>
            <td>{{ row.latitude }}</td>
            <td>{{ row.longitude }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "CameraList",
  components: {},
  props: {
    label: { type: String, default: "" },
    data: { type: Array, default: () => [] },
  },
});
</script>

<style lang="scss" scoped>
.cameralist {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  height: calc(100% - 2px);
  width: calc(100% - 2px);
  border: 1px solid black;
  overflow: hidden;

  .cameralist-label {
    display: flex;
    justify-content: center;
    align-items: center;
    align-content: center;
    width: 100%;
    height: 45px;
    font-size: 2em;
    font-weight: bold;
    padding: 1px;
    background: #272727;
    color: #7f7f7c;

    span {
      text-align: center;
      width: calc(100% - 20px);
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      height: 45px;
    }
  }

  .camera-table {
    overflow: auto;
    font-size: 16px;

    table {
      border-spacing: 2px 0;
    }

    td {
      word-wrap: break-word;
    }

    th {
      width: auto;
      text-align: left;
    }

    span {
      text-align: left;
    }
  }
}
</style>
