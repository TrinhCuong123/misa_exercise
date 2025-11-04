<template>
  <div>
    <DatePicker v-model="dateModel" panelClass="ms-datepicker" class="h-32px" date-format="dd/mm/yy" :placeholder="placeHolder" show-icon fluid />
  </div>
</template>

<script setup>
import DatePicker from 'primevue/datepicker';
const dateModel = defineModel();

defineProps({
  placeHolder: {
    type: String,
    default: ''
  }
})

</script>

<style>
.ms-datepicker {
  width: 100%;
}

.ms-datepicker .p-datepicker {
  width: 100%;
}

.ms-datepicker .p-datepicker-day-selected {
  background: #e0e0e0 !important;
  color: #000000 !important;
}
</style>