<template>
  <div class="ms-datepicker">
    <DatePicker v-model="dateModel" class="h-32px" date-format="dd/mm/yy" placeholder="dd/MM/yyyy" show-icon fluid />
  </div>
</template>

<script setup>
import DatePicker from 'primevue/datepicker';
const dateModel = defineModel();
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