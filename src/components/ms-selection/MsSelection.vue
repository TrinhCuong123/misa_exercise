<template>
  <Select v-model="selectModel" class="paging-selector mr-10" :options="paggingOptions" option-label="label"
    option-value="value" fluid overlayClass="custom-select-overlay" labelClass="custom-label"/>
</template>

<script setup>
import Select from 'primevue/select';
defineProps({
  paggingOptions: {
    type: Array,
    default: () => []
  }
});

const selectModel = defineModel();
</script>

<style>
.custom-select-overlay .p-select-option {
  justify-content: center !important;
}
.custom-select-overlay .p-select-option-selected {
  background-color: rgba(225, 238, 255, 0.8) !important;
  color: rgb(33 37 41) !important;
}
.custom-select-overlay .p-select:hover {
  background-color: #006aff !important;
}
.custom-select-overlay .p-select-label:hover {
  color: #006aff !important;
}
.paging-selector .p-select-label {
  padding: 9px 0 10px 16px !important;
}
</style>